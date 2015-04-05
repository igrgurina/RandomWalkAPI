using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace RandomWalk {
    
    /// <summary>
    /// Main engine interface for route generation
    /// </summary>
    /// <typeparam name="R">Used implementation of IRoute</typeparam>
    /// <typeparam name="L">Used implementation of ILink</typeparam>
    /// <typeparam name="N">Used implementation of ILocationRoute</typeparam>
    public interface IRoutable<R, L, N> where R : IRoute<L,N> where N : ILocationNode where L : ILink<N> {
        /// <summary>
        /// Query platform's engine for available basic filtered routes. 
        /// <para>
        /// Filters are: user's current location and time he has available for walking.
        /// </para>
        /// <param name="currentUserLocation">Current location of the user.</param>  
        /// <param name="timeAvailable">Available time that the user has selected.</param>
        /// </summary>
        IEnumerable<R> QueryBasicRoutes(DbGeography currentUserLocation, TimeSpan timeAvailable);

        /// <summary>
        /// Query platform's engine for available advanced filtered routes. 
        /// <para>
        /// Filters are: user's current location and time he has available for walking.
        /// </para>
        /// </summary>
        /// <param name="currentUserLocation">Current location of the user.</param>  
        /// <param name="timeAvailable">Available time that the user has selected.</param>
        /// <param name="pointsOfInterest">Locations selected by the user</param>
        /// <returns></returns>
        IEnumerable<R> QueryAdvancedRoutes(DbGeography currentUserLocation, TimeSpan timeAvailable, IEnumerable<N> pointsOfInterest);

        /// <summary>
        /// Query platform's engine for locations which can be visited in the time available.
        /// <para>
        /// Filters are: user's current location and time he has available for walking.
        /// </para>
        /// </summary>
        /// <param name="currentUserLocation">Current location of the user.</param>  
        /// <param name="timeAvailable">Available time that the user has selected.</param>
        /// <returns>List of locations which can be visited in the time available</returns>
        IEnumerable<N> QueryPointsOfInterest(DbGeography currentUserLocation, TimeSpan timeAvailable);

    }

}
