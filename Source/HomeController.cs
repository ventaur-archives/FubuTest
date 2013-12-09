using FubuCore;

using FubuMVC.Core.Ajax;


namespace FubuTest {
	public class HomeController {
		public HomeViewModel Home() {
			return new HomeViewModel();
		}

		public AjaxContinuation Post_JsonPost_NoBinding(NoBindingRequestModel request) {
			return BuildCommonContinuation(request);
		}

		public AjaxContinuation Post_JsonPost_WithBinding(WithBindingRequestModel request) {
			var result = BuildCommonContinuation(request);
			result["Username"] = request.CurrentUser.Username;

			return result;
		}

		private static AjaxContinuation BuildCommonContinuation(BaseBindingRequestModel request) {
			var result = AjaxContinuation.Successful();
			result.Message = "Yay, '{0}' from the server!".ToFormat(request.Name);
			return result;
		}
	}


	public class HomeViewModel {}


	public class BaseBindingRequestModel {
		public string Name { get; set; }
	}


	public class NoBindingRequestModel : BaseBindingRequestModel {}


	public class WithBindingRequestModel : BaseBindingRequestModel {
		public User CurrentUser { get; set; }
	}
}