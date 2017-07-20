using UnityEngine;
using System.Collections;

namespace Oddych {
	public interface RestifizerParams {
		string GetClientId();
		string GetClientSecret();
		string GetAccessToken();
	}
}
