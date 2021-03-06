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
    [Table("postnummer")]
    public partial class Postnummer : ReplicationBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public Postnummer()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// DETTE ER PKEY. Unik identifikation af det postnummeret. Postnumre fastsættes af Post Danmark. Repræsenteret ved fire cifre. Eksempel: ”2400” for ”København NV”.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None), Column("nr", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Nr { get; set; }

        /// <summary>
        /// Det navn der er knyttet til postnummeret, typisk byens eller bydelens navn. Repræsenteret ved indtil 20 tegn. Eksempel: ”København NV”.
        /// </summary>
        
        [Column("navn", TypeName = "varchar(20)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>
        /// Hvorvidt postnummeret er en særlig type, der er tilknyttet en organisation der modtager en større mængde post.
        /// </summary>
        
        [Column("stormodtager")]
        [Required()]
        public virtual bool Stormodtager { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        /// Returns the primary key as a string (includes all columns).</summary>
        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Nr.ToString();
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
