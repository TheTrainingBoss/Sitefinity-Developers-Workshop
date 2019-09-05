What Flavor API?
----------------

To work with Sitefinity programmatically:

-   Use the Sitefinity API. This is the full-featured API that provides the deepest set of features for controlling Sitefinity functionality. Use the Sitefinity API to access everything that Sitefinity has to offer. Here is an example of the Sitefinity API that returns all blog posts:

BlogsManager manager = BlogsManager.GetManager();

IQueryable\<BlogPost\> blogs = manager.GetBlogPosts();

You can also use the Fluent API. The Fluent API is a wrapper around the
Sitefinity API that surfaces the most commonly used features.

var blogs = App.WorkWith().BlogPosts().Get().ToList();

-   Use Sitefinity Web services. Sitefinityoffers two ways to work with REST web services from any client platform that can hit a URL, including Linux, Windows, Mac, I-whatever (iPad, iPhone), WPF, Flash, Android, etc.

 The original WCF services can communicate in XML or JSON (for easy access in JavaScript client code). They are mature and offer the most complete coverage, but are more verbose to work with. The example below brings back a list of all blog posts in XML format from \"\<my site\>\".

http://localhost:12345/<mysite>/sitefinity/services/Content/BlogPostService.svc/xml

New to Sitefinity is the Web Services module, which gives you the ability to create API endpoints using the familiar Sitefinity Backend interface. The endpoints are lighter, customizable, and easier to use than the WCF services. This example of an API call returns the list of news items in JSON format:

http://localhost:12345/<my site>/api/default/newsitems