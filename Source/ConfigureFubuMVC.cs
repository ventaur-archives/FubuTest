using FubuMVC.Core;


namespace FubuTest {
	public class ConfigureFubuMVC : FubuRegistry {
		public ConfigureFubuMVC() {
			// All public methods from concrete classes ending in "Controller"
			// in this assembly are assumed to be action methods
			Actions.IncludeClassesSuffixedWithController();

			// Policies
			Routes
				.HomeIs<HomeController>(c => c.Home())
				.IgnoreControllerNamesEntirely()
				.IgnoreMethodSuffix("Html")
				.RootAtAssemblyNamespace();
		}
	}
}