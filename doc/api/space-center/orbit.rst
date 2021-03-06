Orbit
=====

.. class:: Orbit

   Describes an orbit. For example, the orbit of a vessel, obtained by calling
   :meth:`Vessel.Orbit`, or a celestial body, obtained by calling
   :meth:`CelestialBody.Orbit`.

   .. attribute:: Body

      Gets the celestial body (e.g. planet or moon) around which the object is orbiting.

      :rtype: :class:`CelestialBody`

   .. attribute:: Apoapsis

      Gets the apoapsis of the orbit, in meters, from the center of mass of the
      body being orbited.

      .. note:: For the apoapsis altitude reported on the in-game map view, use
         :attr:`Orbit.ApoapsisAltitude`.

      :rtype: double

   .. attribute:: Periapsis

      Gets the periapsis of the orbit, in meters, from the center of mass of the
      body being orbited.

      :rtype: double

      .. note:: For the periapsis altitude reported on the in-game map view, use
         :attr:`Orbit.PeriapsisAltitude`.

   .. attribute:: ApoapsisAltitude

      Gets the apoapsis of the orbit, in meters, above sea level of the body
      being orbited.

      :rtype: double

      .. note:: This is equal to :attr:`Orbit.Apoapsis` minus the equatorial
         radius of the body.

   .. attribute:: PeriapsisAltitude

      Gets the periapsis of the orbit, in meters, above sea level of the body
      being orbited.

      :rtype: double

      .. note:: This is equal to :attr:`Orbit.Periapsis` minus the equatorial
         radius of the body.

   .. attribute:: SemiMajorAxis

      Gets the semi-major axis of the orbit, in meters.

      :rtype: double

   .. attribute:: SemiMinorAxis

      Gets the semi-minor axis of the orbit, in meters.

      :rtype: double

   .. attribute:: Radius

      Gets the current radius of the orbit, in meters. This is the distance
      between the center of mass of the object in orbit, and the center of mass
      of the body around which it is orbiting.

      :rtype: double

      .. note:: This value will change over time if the orbit is elliptical.

   .. attribute:: Speed

      Gets the current orbital speed of the object in meters per second.

      :rtype: double

      .. note:: This value will change over time if the orbit is elliptical.

   .. attribute:: Period

      Gets the orbital period, in seconds.

      :rtype: double

   .. attribute:: TimeToApoapsis

      Gets the time until the object reaches apoapsis, in seconds.

      :rtype: double

   .. attribute:: TimeToPeriapsis

      Gets the time until the object reaches periapsis, in seconds.

      :rtype: double

   .. attribute:: Eccentricity

      Gets the `eccentricity
      <http://en.wikipedia.org/wiki/Orbital_eccentricity>`_ of the orbit.

      :rtype: double

   .. attribute:: Inclination

      Gets the `inclination <http://en.wikipedia.org/wiki/Orbital_inclination>`_
      of the orbit, in radians.

      :rtype: double

   .. attribute:: LongitudeOfAscendingNode

      Gets the `longitude of the ascending node
      <http://en.wikipedia.org/wiki/Longitude_of_the_ascending_node>`_, in
      radians.

      :rtype: double

   .. attribute:: ArgumentOfPeriapsis

      Gets the `argument of periapsis
      <http://en.wikipedia.org/wiki/Argument_of_periapsis>`_, in radians.

      :rtype: double

   .. attribute:: MeanAnomalyAtEpoch

      Gets the `mean anomaly at epoch
      <http://en.wikipedia.org/wiki/Mean_anomaly>`_.

      :rtype: double

   .. attribute:: Epoch

      Gets the time since the epoch (the point at which the `mean anomaly at
      epoch <http://en.wikipedia.org/wiki/Mean_anomaly>`_ was measured, in
      seconds.

      :rtype: double

   .. attribute:: MeanAnomaly

      Gets the `mean anomaly <http://en.wikipedia.org/wiki/Mean_anomaly>`_.

      :rtype: double

   .. attribute:: EccentricAnomaly

      Gets the `eccentric anomaly
      <http://en.wikipedia.org/wiki/Eccentric_anomaly>`_.

      :rtype: double

   .. method:: ReferencePlaneNormal (referenceFrame)

      Gets the unit direction vector that is normal to the orbits reference
      plane, in the given reference frame. The reference plane is the plane from
      which the orbits inclination is measured.

      :param ReferenceFrame referenceFrame:
      :rtype: :class:`Vector3`

   .. method:: ReferencePlaneDirection (referenceFrame)

      Gets the unit direction vector from which the orbits longitude of
      ascending node is measured, in the given reference frame.

      :param ReferenceFrame referenceFrame:
      :rtype: :class:`Vector3`

   .. attribute:: TimeToSOIChange

      Gets the time until the object changes sphere of influence, in
      seconds. Returns ``NaN`` if the object is not going to change sphere of
      influence.

      :rtype: double

   .. attribute:: NextOrbit

      If the object is going to change sphere of influence in the future,
      returns the new orbit after the change. Otherwise returns ``null``.

      :rtype: :class:`Orbit`
