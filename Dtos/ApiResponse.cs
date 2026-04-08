using L3C1WebAPI.Data.Entities;

namespace L3C1WebAPI.Dtos
{
	public class ApiResponse<T>
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data {get; set;}
		public List<string>? Errors { get; set; }
	}

	


}
