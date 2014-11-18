package mono.com.worklight.wlclient;


public class HttpPostListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.HttpPostListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onException:(Ljava/lang/Exception;)V:GetOnException_Ljava_lang_Exception_Handler:Worklight.Android.IHttpPostListenerInvoker, Worklight.Android\n" +
			"n_onResponse:(Lorg/apache/http/HttpResponse;)V:GetOnResponse_Lorg_apache_http_HttpResponse_Handler:Worklight.Android.IHttpPostListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Android.IHttpPostListenerImplementor, Worklight.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HttpPostListenerImplementor.class, __md_methods);
	}


	public HttpPostListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HttpPostListenerImplementor.class)
			mono.android.TypeManager.Activate ("Worklight.Android.IHttpPostListenerImplementor, Worklight.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onException (java.lang.Exception p0)
	{
		n_onException (p0);
	}

	private native void n_onException (java.lang.Exception p0);


	public void onResponse (org.apache.http.HttpResponse p0)
	{
		n_onResponse (p0);
	}

	private native void n_onResponse (org.apache.http.HttpResponse p0);

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
