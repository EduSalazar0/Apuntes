namespace Apuntes.Views;
[QueryProperty(nameof(ItemId),nameof(ItemId))]
public partial class NotePage : ContentPage
{
	public string ItemId
	{
		set { LoadNote(value); }
	}

	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "ESalazar_notes.txt");
	public NotePage()
	{
		InitializeComponent();
		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.ESalazar_notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
	}
	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		if(BindingContext is Models.Note note)
			File.WriteAllText(note.FileName, ESalazar_TextEditor.Text);

		await Shell.Current.GoToAsync("..");
	}

	private async void DeleteButton_Clicked(object sender, EventArgs e)
	{
		if(BindingContext is Models.Note note)
		{
			if(File.Exists(note.FileName))
				File.Delete(note.FileName);
		}
		await Shell.Current.GoToAsync("..");
	}
	private void LoadNote(string filename)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.FileName = filename;
		if(File.Exists(filename))
		{
			noteModel.Date = File.GetCreationTime(filename);
			noteModel.Text = File.ReadAllText(filename);
		}
		BindingContext = noteModel;
	}
}