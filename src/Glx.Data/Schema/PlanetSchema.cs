namespace Glx.Data.Schema {
    public class PlanetSchema {
        #region Columns

        public long Id { get; set; }

        public string Name { get; set; }

        public string Climate { get; set; }

        public string Diameter { get; set; }

        public string Gravity { get; set; }

        public string OrbitalPeriod { get; set; }

        public string Population { get; set; }

        public string RotationPeriod { get; set; }

        public string Terrain { get; set; }

        public string WaterCoverage { get; set; }

        #endregion

        #region Relations

        public virtual ICollection<MovieSchema> Movies { get; } = new HashSet<MovieSchema>();

        public virtual ICollection<CharacterSchema> Residents { get; } = new HashSet<CharacterSchema>();

        #endregion
    }
}
