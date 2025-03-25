namespace DropoutCoder.StarWars.Data.Schema {
    public class SpeciesSchema {
        #region Columns
        public long Id { get; set; }

        public string Name { get; set; }

        public string AverageLifespan { get; set; }

        public string Classification { get; set; }

        public string Designation { get; set; }

        public string EyeColor { get; set; }

        public string HairColor { get; set; }

        public string Height { get; set; }

        public string Language { get; set; }

        public string SkinColor { get; set; }

        #endregion

        #region Relations

        public virtual PlanetSchema? Planet { get; set; }

        public virtual ICollection<CharacterSchema> Characters { get; set; } = new HashSet<CharacterSchema>();

        public virtual ICollection<MovieSchema> Movies { get; set; } = new HashSet<MovieSchema>();

        #endregion
    }
}
