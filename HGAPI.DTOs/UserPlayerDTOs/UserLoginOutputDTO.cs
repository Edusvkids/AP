namespace HGAPI.DTOs.UserPlayerDTOs
{
    public class UserLoginOutputDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int LevelPlayer { get; set; }
        public string Token { get; set; }
    }
}
