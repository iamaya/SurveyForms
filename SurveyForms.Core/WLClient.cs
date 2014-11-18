using System;
using Worklight;
using Worklight.Xamarin.Android;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SurveyForms.Core.Models.WorkLight;

namespace SurveyForms.Core
{
	/// <summary>
	/// Sample Worklight client 
	/// </summary>
	public class WLClient
	{
		#region Fields

		private string pushAlias = "myAlias2";
		private string appRealm = "SampleAppRealm";
	//	private JsonObject metadata = (JsonObject)JsonObject.Parse(" {\"platform\" : \"Xamarin\" } ");

		#endregion

		#region Properties

		public IWorklightClient client { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this instance is push supported.
		/// </summary>
		/// <value><c>true</c> if this instance is push supported; otherwise, <c>false</c>.</value>
		public bool IsPushSupported
		{
			get
			{
				try
				{
					return client.PushService.IsPushSupported;
				}
				catch
				{
					return false;
				}

			}

		}

		/// <summary>
		/// Gets a value indicating whether this instance is subscribed.
		/// </summary>
		/// <value><c>true</c> if this instance is subscribed; otherwise, <c>false</c>.</value>
		public bool IsSubscribed
		{
			get
			{
				try
				{
					return client.PushService.IsAliasSubscribed(pushAlias);
				}
				catch
				{
					return false;
				}


			}

		}

		#endregion

		#region Constuctors

		public WLClient(IWorklightClient wlc)
		{
			this.client = wlc;
		}

		#endregion

	

		public async Task<WorklightResult> ConnectAsync()
		{
			var result = new WorklightResult();

			try
			{
				var resp = await Connect();

				result.Success = resp.Success;
				result.Message = (resp.Success) ? "Connected" : resp.Message;
				result.Response = resp.ResponseText;
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}

			return result;
		}

		private async Task<WorklightResponse> Connect()
		{
			//lets send a message to the server
		//	client.Analytics.Log("Trying to connect to server", metadata);

			ChallengeHandler customCH = new CustomChallengeHandler(appRealm);
			client.RegisterChallengeHandler(customCH);
			WorklightResponse task = await client.Connect();
			//lets log to the local client (not server)
		//	client.Logger("Xamarin").Trace("connection");
			//write to the server the connection status
			//client.Analytics.Log("Connect response : " + task.Success);
			return task;
		}




	}



}

