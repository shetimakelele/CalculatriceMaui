﻿using System;

namespace CalculatriceMaui;

public partial class MainPage : ContentPage
{
	int currentState = 1;
	double firstNum, secondNum;
	string operatorMath;

	public MainPage()
	{
		InitializeComponent();
		OnClear(this, null);
	}


	void OnClear(object sender, EventArgs e)
	{
		firstNum= 0;
		secondNum= 0;
		currentState= 1;
		this.result.Text = "0";
	}

	void OnSquareRoot(object sender, EventArgs e)
	{
		if (firstNum == 0)
			return;
		firstNum = firstNum * firstNum;
		this.result.Text = firstNum.ToString();
	}

	void OnNumberSelection(object sender, EventArgs e)
	{
		Button button= (Button)sender;
		string btnPressed = button.Text;

		if(this.result.Text == "0" || currentState < 0)
		{
			this.result.Text = string.Empty;
			if(currentState <0)
				currentState *= -1;
		}

		this.result.Text += btnPressed;
		double number;
		if(double.TryParse(this.result.Text,out number)) 
		{
			this.result.Text = number.ToString("NO");
			if(currentState == 1)
			{
				firstNum= number;
			}
			else
			{
				secondNum= number;
			}
		}
	}
	void OnOperatorSelection(object sender, EventArgs e)
	{
		currentState = -2;
		Button button= (Button)sender;
		string btnPressed = button.Text;
		operatorMath = btnPressed;
	}



}

