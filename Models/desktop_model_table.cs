using System.ComponentModel.DataAnnotations;
namespace quizzer_backend.Models
{
    public class desktop_model_table : BaseEntity
    {
	[Key]
	public int    Id {get;set;}
	[Required]
	public string display_name {get; set;}
	[Required]
	public double review_score {get; set;}
	public double price {get; set;}
	public string cpu_model_name {get; set;}
	public int 	  cpu_benchmark {get; set;}
	public string hd_model_name {get; set;}
	public int    hd_capacity_gb {get; set;}
	public string hd_type {get; set;}
	public int    ram_gb {get; set;}
	public string gpu_model_name {get; set;}
	public int    gpu_benchmark {get; set;}
	public string features {get; set;}
	public string url_to_product_page {get; set;}
	public string model_number {get; set;}
	
    }
}
