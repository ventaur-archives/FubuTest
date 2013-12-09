using System;
using System.Reflection;

using FubuCore.Binding;


namespace FubuTest.Conventions {
	public class CurrentUserBinder : IPropertyBinder {
		private static readonly User _currentUser = new User {
			Id = Guid.NewGuid(),
			Username = "FubuGuy"
		};

		public bool Matches(PropertyInfo property) {
			return (property.PropertyType == typeof(User) && property.Name == "CurrentUser");
		}

		public void Bind(PropertyInfo property, IBindingContext context) {
			property.SetValue(context.Object, _currentUser);
		}
	}
}