﻿using System;
using System.ComponentModel;
using UnityEngine;
using ZFrame.Debugger;
using ZFrame.Frame.MVVM;

[ViewModel]
public class MVVMDemoViewModel : MonoBehaviour, INotifyPropertyChanged
{
	private string _key;
	private int _id;

	public string Key
	{
		get { return _key; }
		set
		{
			if (_key != value)
			{
				_key = value;
				//MVVMEngine.Instance.Notify(() => Key);
				OnPropertyChanged("Key");
			}
		}
	}

	public int ID
	{
		get { return _id; }
		set
		{
			if (_id != value)
			{
				_id = value;
				MVVMEngine.Instance.Notify(this, "ID");
				//OnPropertyChanged("ID");
			}
		}
	}

	private void Update()
	{
		Key = DateTime.Now.ToLongTimeString();
		ID = DateTime.Now.Second;
	}

	private void Awake()
	{
		MVVMEngine.Instance.Register(this);
	}

	public void MethodA()
	{
		ZDebug.Log("MethodA");
	}

	public void MethodB(string value)
	{
		ZDebug.Log("MethodB: " + value);
	}

	public void MethodC(string value, int value2)
	{
		ZDebug.Log("MethodB: " + value + " -- " + value2);
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChangedEventHandler handler = PropertyChanged;
		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	}
}