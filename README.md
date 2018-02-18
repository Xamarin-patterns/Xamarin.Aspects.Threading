# Xamarin.Aspects.Threading
Although  postsharp has declared before that they do not support xamarin anymore , it still can be used with dot net standard that gave us some home that we still can move out the boilerplate code from our track , keep our code bases clean and readable. 
This repository should contains postsharp aspects that are related to the threading concerns ie moving methods excution between foreground and background thread , showing progress bar and loading bar while a long operation is excuted.


## Getting Started
Install from nuget 


### Note

Do not install postsharp in your xamarin.ios or xamarin.android projects otherwise the compiler will complain saying that postsharp does not support xamarin anymore.

```
## Aspects to use
```
### ShowLoader
This aspect depend on [Acr.UserDialogs](https://github.com/aritchie/userdialogs) library so you must initialize the acr library in your Android and Ios projects.

    [ShowLoader]
    public async void TestLoader()
    {
    await Task.Delay(1000);
    }
    
### BackgroundThread
using this aspect will move the excution on the decorated method from the main UI thread to a background thread , for example the method below would block the UI thread in normal case (if the BackgroundThread) is not presented but due to it is present , it wont block the ui thread. 
    
    [BackgroundThread]
    public void TestLoader()
    {
    Task.Delay(10000).Wait();
    }
    
### ForegroundThread
move the excution of the decorated method to the ui Thread , very useful when it is required to update the user interface after some async work.

    public async Task BackgroundMethod()
    {
    Task.Run(async()=>{
     var data=await GetData();
     ShowToUI(data);
    });
    }
    
    [ForegroundThread]
    public void ShowToUI(List<Items> data){
    listview.Itemssource=data;
    }
    
## Acknowledgments

* We are using postsharp to build this aspects as we beilive that postsharp allow us to access the future of c# after using this aspects you will find that your code will become shorter , more readable and more SOLID.
* We are not connected in anyway with Postsharp or Xamarin. 
* You are free to post suggestions and we will keep an eye one every issue and every pull request.

