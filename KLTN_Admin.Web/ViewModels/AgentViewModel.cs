using System.ComponentModel.DataAnnotations;

namespace KLTN_Admin.Web.ViewModels
{
    public class AgentViewModel
    {
        public string Id { get; set; }
        
        [Display(Name = "Tên Nhà Xe")]
        public string AgentName { get; set; }
        
        [Display(Name = "Phí Hủy")]
        public int CancelFee { get; set; }
    }
}
