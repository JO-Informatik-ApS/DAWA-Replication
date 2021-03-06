//-----------------------------------------------------------------------------------------------
// This is auto-generated code.
//-----------------------------------------------------------------------------------------------
// This code was generated by JO Informatik DAWA Replication tool version 1.0.2.0
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//-----------------------------------------------------------------------------------------------
using Microsoft.SqlServer.Types;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>TODO.</summary>
    [GeneratedCode("JO Informatik DAWA Replication tool", "version 1.0.2.0")]
    [Table("sted")]
    public partial class Sted : ReplicationBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public Sted()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// DETTE ER PKEY. stedets ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None), Column("id")]
        [Required()]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Stedets hovedtype.
        /// </summary>
        
        [Column("hovedtype", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Hovedtype { get; set; }

        /// <summary>
        /// Stedets undertype
        /// </summary>
        
        [Column("undertype", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Undertype { get; set; }

        /// <summary>
        /// Unik 5-cifret kode der identificerer en by eller et sommerhusområde
        /// </summary>
        
        [Column("bebyggelseskode")]
        public virtual int? Bebyggelseskode { get; set; }

        /// <summary>
        /// Antal indbyggere indenfor objektets udstrækning.
        /// </summary>
        
        [Column("indbyggerantal")]
        public virtual int? Indbyggerantal { get; set; }

        /// <summary>
        /// Stedets visuelle center.
        /// </summary>
        
        [Column("visueltcenter")]
        [Required()]
        [JsonConverter(typeof(SqlGeometryConverter))]
        public virtual SqlGeometry Visueltcenter { get; set; }

        /// <summary>
        /// Bounding box for stedets geometri. Null hvis stedets geometri ikke har nogen fysisk udstrækning.
        /// </summary>
        
        [Column("bbox")]
        [JsonConverter(typeof(SqlGeometryConverter))]
        public virtual SqlGeometry Bbox { get; set; }

        /// <summary>
        /// Stedets geometri
        /// </summary>
        
        [Column("geometri")]
        [Required()]
        [JsonConverter(typeof(SqlGeometryConverter))]
        public virtual SqlGeometry Geometri { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        /// Returns the primary key as a string (includes all columns).</summary>
        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Id.ToString();
                }
                return _dawaPkey;
            }
        }

        [Column("entity_updated")]
        [Required()]
        /// <summary>Tidspunktet da rækken blev oprettet eller ændret i databasen hos JOI.</summary>
        public DateTime EntityUpdated { get; set; }

    }
}
