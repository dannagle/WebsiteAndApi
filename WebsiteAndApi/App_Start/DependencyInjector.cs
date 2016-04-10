﻿using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using DevSpace.Api.Controllers;

namespace DevSpace {
	/// <summary>Allows the controllers to use the correct database.</summary>
	/// <remarks>
	///		This class glues a lot of things together.
	///		Please do not include usings for any of the external DevSpace libraries.
	/// </remarks>
	internal class DependencyInjector : IDependencyResolver {
		public DependencyInjector() {
			Common.IDatabase Database = new Database.SqlDatabase();
			Database.Initialize();
		}

		public object GetService( Type serviceType ) {
			switch( serviceType.Name ) {
				case nameof( SponsorController ):
					return new SponsorController( new Database.SponsorDataStore() );
			}

			return null;
		}

		public IEnumerable<object> GetServices( Type serviceType ) {
			return new List<object>();
		}

		public IDependencyScope BeginScope() {
			return this;
		}

		public void Dispose() {
		}
	}
}