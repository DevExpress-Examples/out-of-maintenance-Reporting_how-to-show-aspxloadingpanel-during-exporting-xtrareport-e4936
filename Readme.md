<!-- default file list -->
*Files to look at*:

* **[Default.aspx](./CS/E4936/Default.aspx) (VB: [Default.aspx](./VB/E4936/Default.aspx))**
* [Default.aspx.cs](./CS/E4936/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/E4936/Default.aspx.vb))
<!-- default file list end -->
# How to show ASPxLoadingPanel during exporting XtraReport
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4936/)**
<!-- run online end -->


<p>This example demonstrates how to show a loading panel while a document of an exported report is being created on the server side.</p><p>When an exported document is large, it takes several seconds to export it, and you might want to show ASPxLoadingPanel during exporting. The main issue is that a document should be exported on a full page postback and written to the server response, and it is impossible to show APSxLoadingPanel during a full page postback. </p><br />
<p>The main idea of this approach is to perform exported document generation on a page callback, save the resulting document in the server memory, and after that perform a full page postback just to get a generated document from memory and write it to the Response. </p><br />
<p>As document generation is processed on a callback, it is possible to display a loading panel while a callback is being processed.</p><p><strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2293">E2293: How to show ASPxLoadingPanel during export</a></p>

<br/>


