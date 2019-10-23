namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Som koordinatsystem kan anvendes ETRS89/UTM32 med srid=25832 eller WGS84/geografisk med srid=4326.
    /// </summary>
    public enum KoordinatsystemSrid
    {
        /// <summary>Koordinatsystem ETRS89/UTM32.</summary>
        ETRS89 = 25832,

        /// <summary>Koordinatsystem WGS84/geografisk.</summary>
        WGS84 = 4326
    }
}
