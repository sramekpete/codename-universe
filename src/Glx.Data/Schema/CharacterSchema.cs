namespace Glx.Data.Schema {
    public class CharacterSchema {
        #region Columns

        public long Id { get; set; }

        public string Name { get; set; }

        public string EyeColor { get; set; }

        public string Gender { get; set; }

        public string HairColor { get; set; }

        public string Height { get; set; }

        public string SkinColor { get; set; }

        public string YearOfBirth { get; set; }

        #endregion

        #region Relations

        public virtual PlanetSchema Planet { get; set; }

        public virtual ICollection<SpeciesSchema> Species { get; set; } = new HashSet<SpeciesSchema>();

        public virtual ICollection<MovieSchema> Movies { get; set; } = new HashSet<MovieSchema>();

        public virtual ICollection<StarshipSchema> Starships { get; set; } = new HashSet<StarshipSchema>();

        public virtual ICollection<VehicleSchema> Vehicles { get; set; } = new HashSet<VehicleSchema>();

        #endregion
    }
}
