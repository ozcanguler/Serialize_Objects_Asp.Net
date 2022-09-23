namespace Button.Utility
{
    public class GameObject
    {
        public GameObject(int id, string jSONstring)
        {
            Id = id;
            JSONstring = jSONstring;
        }

        public int Id { get; set; }
        public string JSONstring { get; set; }
    }
}