package worklight.xamarin.android;


public class ESNotificationListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.api.WLEventSourceListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Ljava/lang/String;Ljava/lang/String;)V:GetOnReceive_Ljava_lang_String_Ljava_lang_String_Handler:Worklight.Android.IWLEventSourceListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.ESNotificationListener, Worklight.Xamarin.Android, Version=1.0.0.21095, Culture=neutral, PublicKeyToken=null", ESNotificationListener.class, __md_methods);
	}


	public ESNotificationListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ESNotificationListener.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.ESNotificationListener, Worklight.Xamarin.Android, Version=1.0.0.21095, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (java.lang.String p0, java.lang.String p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (java.lang.String p0, java.lang.String p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
