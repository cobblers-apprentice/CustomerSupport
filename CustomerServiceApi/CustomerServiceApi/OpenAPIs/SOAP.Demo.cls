 <html>
 <head>
 <style type="text/css">
		body { color: #000000; background-color: #ddddff; font-size: .8em; font-family: Verdana; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 30px; padding-bottom: 2em; }
		a:link { color: #000099; font-weight: bold; text-decoration: underline; }
		a:active { color: #000099; font-weight: bold; text-decoration: underline; }
		a:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		p { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: Verdana; }
		table  { color: #000000; font-family: Verdana; }
		td { color: #000000; font-family: Verdana; font-size: .8em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #000088; margin-left: -15px; color: #000088; }
		h3 { font-size: 1.1em; color: #000000; margin-left: -15px; margin-top: 10px; margin-bottom: 10px; }
		ul, ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		.heading1 { color: #ffffff; font-family: Tahoma; font-size: 2.2em; font-weight: normal; background-color: #000088; margin-top: 0px; margin-bottom: 0px; margin-left: -30px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 105%; }
		.button { background-color: #dcdcdc; font-family: Verdana; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.intro { margin-left: -15px; }
		.description { margin-left: -15px; font-size: 1.1 em; }
 </style>
 <title>Web Service SOAP.Demo</title>
 </head>
 

<body><div id="content"><p class="heading1">Web Service SOAP.Demo </p><br>
<p class="intro">A simple demonstration Web Service<BR>
To try this, visit
<A href="/csp/samples/SOAP.Demo.cls">/csp/samples/SOAP.Demo.cls</A>
This web service inherits from the SOAP.BaseService sample class 
 to pickup common error handling.</p>
<hr>
<p class="intro">This web service is using <b>http://tempuri.org</b> as its default namespace.</p>
<p class="intro">The name of this web service is <b>SOAPDemo</b></p>
<p class="intro">The following operations are supported.  For a formal definition, please review the <a href="SOAP.Demo.CLS?WSDL=1">Service Description</a></p>
<ul>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=AddInteger">AddInteger</a><p>
Adds two integers and returns the result.
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=DivideInteger">DivideInteger</a><p>
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=FindPerson">FindPerson</a><p>
Returns data about the person in the database with
object ID of <var>id</var>.
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=GetByName">GetByName</a><p>
A sample web method to invoke dynamic SQL to query the Sample.Person class and
   return the results as a .NET untyped DataSet
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=GetDataSetByName">GetDataSetByName</a><p>
A sample web method to invoke the ByName query of the Sample.Person class and
return the results as a .NET typed DataSet
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=GetListByName">GetListByName</a><p>
A sample web method to invoke dynamic SQL to query the Sample.Person class and
return the results as a list of objects.
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=LookupCity">LookupCity</a><p>
Returns the city and state for the given U.S. ZIP Code
packaged within a <class>Sample.Address</class> object.
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=Mission">Mission</a><p>
Returns a corporate mission statement.
</p></li>
<li><a href="%25SOAP.WebServiceInvoke.cls?CLS=SOAP.Demo&amp;OP=QueryByName&amp;QUERY=1">QueryByName</a><p>
A sample class query as a WebMethod that defines a typed dataset that returns Person data 
ordered by <property>Name</property>.<br>
This query also generates a WebMethod of the same name that may be called using SOAP
in order to return a typed .Net DataSet.
</p></li>
</ul>
</div></body></html>
