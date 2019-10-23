using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Entity base class. Holds commmon haendelser JSON fields that are NOT stored in the entity tables.
    /// </summary>
    public class EntityBase
    {
        protected string _dawaPkey = null;

        /// <summary>Gets or sets CRUD operation (from haendelser JSON).</summary>
        [NotMapped]
        public EntityCrudOperation EntityCrudOperation { get; set; }

        /// <summary>
        /// Fill field EntityTxid, EntityCrudOperation and EntityTidspunkt.
        /// </summary>
        /// <param name="item">JSON from http://dawa.aws.dk/replikering/haendelser?entitet=Xxx</param>
        public virtual void SetEntityFields(JObject item)
        { }

        [NotMapped]
        /// <summary>Returns the primary key as a string (includes all columns separeted by underscore).</summary>
        public virtual string DawaPkey { get { return _dawaPkey; } }
    }

    /// <summary>Database CRUD operation type for the entity.</summary>
    public enum EntityCrudOperation
    {
        /// <summary>Default value.</summary>
        Unknown = 0,

        /// <summary>Database INSERT (aka Create).</summary>
        Insert,

        /// <summary>Database UPDATE.</summary>
        Update,

        /// <summary>Database DELETE.</summary>
        Delete
    }

}
