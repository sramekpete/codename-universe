namespace Glx.Data.Schema {
    public class VehicleSchema {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CargoCapacity { get; set; }

        public string Consumables { get; set; }

        public string Class { get; set; }

        public string Crew { get; set; }

        public string Length { get; set; }

        public string Manufacturer { get; set; }

        public string MaxAtmosphericSpeed { get; set; }

        public string Model { get; set; }

        public string Passengers { get; set; }

        public string Price { get; set; }

        public virtual ICollection<MovieSchema> Movies { get; set; } = new HashSet<MovieSchema>();

        public virtual ICollection<CharacterSchema> Pilots { get; set; } = new HashSet<CharacterSchema>();
    }
}
