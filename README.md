# AsyncLoadDialog
**A tool help to  provide a async loading dialog when Perform time-consuming operations，support WinForm and WPF**

![image](https://github.com/semonpic/AsyncLoadDialog/blob/master/img/winform.png)

![image](https://github.com/semonpic/AsyncLoadDialog/blob/master/img/wpfexample.png)


When we perform a time-consuming operation,we need Pop up a  friendly Mode dialog which show the Progress of work,such as download a large file.
How to simplify this work，AsyncLoadDialog Will Help。
With The Help Of AsyncLoadDialog,we only need Foucus On our main job,Do not care about how to control the progress bar, cancel operations and so on。
Only Need Two Step


# 1.Creat a Class extent from AsyncLoad,implement main method Woker
    class DemoAsyncLoad : AsyncLoad
    {
        public override void Worker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;

            try
            {

                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(10, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(20, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(30, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(40, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                //If User Cancel
                if (backgroundWorker.CancellationPending)
                {
                    backgroundWorker.ReportProgress(80, new ProcessResult() { ProcessState = eProcessState.Cancel });
                    return;
                }
                backgroundWorker.ReportProgress(90, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(100, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(500);
                //Work Compelete,Return By Set Content And ProcessState eProcessState.Compelete
                backgroundWorker.ReportProgress(100, new ProcessResult() { ProcessState = eProcessState.Compelete, Content = "Loaded Data" });
            }
            catch
            {
                backgroundWorker.ReportProgress(100, new ProcessResult() { ProcessState = eProcessState.Fail, Content = "Error Msg" });
            }
        }
    }
    
    
##     2   ShowDialog,if Complete, Get RerutnOBj        
            DemoAsyncLoad normalDemoAsyncLoad = new DemoAsyncLoad();
            AsyncLoadForm asyncLoadForm = new AsyncLoadForm(normalDemoAsyncLoad);
            asyncLoadForm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult res = asyncLoadForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                 object loadedObj = asyncLoadForm.ReturnObj;
                 //TODO
            }
            else
            {
                //TODO
                
            }


