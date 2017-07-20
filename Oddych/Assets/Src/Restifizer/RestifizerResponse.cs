using UnityEngine.Networking;
using System.Collections;

namespace Oddych {
	public class RestifizerResponse {
		public bool IsList;
		public bool HasError;
		public Hashtable Resource;
		public ArrayList ResourceList;
		public RestifizerError Error;
		public int Status;
		public string Tag;
		public RestRequest Request;

		public RestifizerResponse(RestRequest request, Hashtable result, string tag) {
			this.IsList = false;
			this.Status = (int) request.responseCode;
			this.Resource = result;
			this.HasError = false;
			this.Request = request;
            this.Tag = tag;
		}

		public RestifizerResponse(RestRequest request, ArrayList result, string tag) {
			this.IsList = true;
			this.Status = (int) request.responseCode;
			this.ResourceList = result;
            this.HasError = false;
			this.Request = request;
			this.Tag = tag;
		}

		public RestifizerResponse(RestRequest request, RestifizerError error, string tag) {
			this.Status = (int) request.responseCode;
			this.HasError = true;
			this.Error = error;
			this.Request = request;
			this.Tag = tag;
		}
	}
}
