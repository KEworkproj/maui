namespace phoneword
{
	public partial class MainPage : ContentPage
	{


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public MainPage()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{
			InitializeComponent();
		}

		string translatedNumber;

		private void OnTranslate(object sender, EventArgs e)
		{
			string enteredNumber = PhoneNumberText.Text;
			translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

			if (!string.IsNullOrEmpty(translatedNumber))
			{
				// TODO:enables the button if the test is true

				CallButton.IsEnabled = true;
				CallButton.Text = "Call " + translatedNumber;
			}
			else
			{
				// TODO:dis able the button
				CallButton.IsEnabled = false;
				CallButton.Text = "Call";
			}
		

			}
		async void OnCall(object sender, System.EventArgs e)
		{
			if (await this.DisplayAlert(
					"Dial a Number",
					"Would you like to call " + translatedNumber + "?",
					"Yes",
					"No"))
			{
				// TODO: dial the phone
				try
				{
					if (PhoneDialer.Default.IsSupported)
						PhoneDialer.Default.Open(translatedNumber);
				}
				catch (ArgumentNullException)
				{
					await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
				}
				catch (Exception)
				{
					// Other error has occurred.
					await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
				}
			}
		}
	}

}
