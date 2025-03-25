namespace Glx.Data.Schema {
    using System;

    public class MovieSchema {
        #region Columns

        public long Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public string Episode { get; set; }

        public string Introduction { get; set; }

        public string Producer { get; set; }

        public DateTime Released { get; set; }

        #endregion

        #region Relations

        public virtual ICollection<CharacterSchema> Characters { get; set; } = new HashSet<CharacterSchema>();

        public virtual ICollection<PlanetSchema> Planets { get; set; } = new HashSet<PlanetSchema>();

        public virtual ICollection<SpeciesSchema> Species { get; set; } = new HashSet<SpeciesSchema>();

        public virtual ICollection<StarshipSchema> Starships { get; set; } = new HashSet<StarshipSchema>();

        public virtual ICollection<VehicleSchema> Vehicles { get; set; } = new HashSet<VehicleSchema>();

        #endregion
    }
}
