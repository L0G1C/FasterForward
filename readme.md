Talewrolds.CampaignSystem.Campaign.cs has a `TickMapTime(float realDt)` which checks for value of CampaignTimeControlMode enum. 

If the CampaignTimeControlMode is StoppableFastForward then it multiples by a SpeedupMultiplier which there 
currently is only one and is 4f. 
- We need to add a second speedupmultipler at 8f perhaps.

To get the new CampaignTimeControlMode to the TickMapTime value we want to set the TimeControlMode 
which is done in `Campaign.SetTimeSpeed(int speed)`.
There there is a switch on speed (case 0, 1, 2) it sets it accoridngly, 2 being the one
That eventually sets the Enum to StoppableFastForward.
- We need to add a 4th option, case 3, which sets to new enum value: StoppableFasterForward.
- Then back on TickMapTime, if the CampaignTimeControlMode is StoppableFasterForward, we set num to the second, 
  higher speedupmultipler
  
  
The Campaign.SetTimeSpeed() method is eventually called (From the UI) from `MapTimeControlVM.cs`
there is a privat emethod `SetTimeSpeed(int speed)` there that calls Campaign.Current.SetTimeSpeed(speed).
the private method in the VM is called from `public void ExecuteTimeControlChange(int selectedTimeSpeed)`
in the VM.
They do some crazy ass logic here I think to validate that the time can be switched? but ultimately just pass the
SelectedTimeSpeed to the SetTimeSpeed() which calls the campaign class method.

Finally. 
In TaleWorlds.CampaignSystem.ViewModelCollection.MapVM.cs there is a check every ticket for the current TimeControlMode in
`public void Tick(float dt)` and during initializing it binds the "OnTimeControlChange" action to the MapTimeControlVM

The MapControlVM object has references to GameTexts and hotkeys:
			GameTexts.SetVariable("TEXT", GameTexts.FindText("str_fast_forward", null).ToString());
			GameTexts.SetVariable("HOTKEY", this._shortcuts.FastForwardHotkey);
			this.FastForwardHint = new HintViewModel(GameTexts.FindText("str_hotkey_with_hint", null).ToString(), null);
			
			
Somehow MapVM actually ties to the UI we see on the screen.