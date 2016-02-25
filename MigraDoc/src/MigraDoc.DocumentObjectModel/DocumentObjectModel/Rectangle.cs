// SRG
using System;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using System.Reflection;
using MigraDoc.DocumentObjectModel.Internals;

namespace MigraDoc.DocumentObjectModel
{
	public enum RectangleBorderStyle // Compatible with XDashStyle
	{
		Solid = 0,
		Dash = 1,
		Dot = 2,
		DashDot = 3,
		DashDotDot = 4,
		Custom = 5,
	}

	/// <summary>
	/// The Rectangle class represents a rounded rectangle surrounding text
	/// </summary>
	public struct Rectangle : INullableValue
	{
		/// <summary>
		/// Determines whether this rectangle is empty.
		/// </summary>
		public bool IsEmpty
		{
			get { return this == Rectangle.Empty; }
		}

		/// <summary>
		/// Returns the value.
		/// </summary>
		object INullableValue.GetValue()
		{
			return this;
		}

		/// <summary>
		/// Sets the given value.
		/// </summary>
		void INullableValue.SetValue(object value)
		{
			Rectangle o = (Rectangle)value;
			_minWidth = o._minWidth;
			_minHeight = o._minHeight;
			_cornerRadius = o._cornerRadius;
			_padding = o._padding;
			_dashStyle = o._dashStyle;
			_dashPattern = o._dashPattern;
			_background = o._background;
			_foreground = o._foreground;
		}

		/// <summary>
		/// Resets this instance, i.e. IsNull() will return true afterwards.
		/// </summary>
		void INullableValue.SetNull()
		{
			this = Rectangle.Empty;
		}

		/// <summary>
		/// Determines whether this instance is null (not set).
		/// </summary>
		bool INullableValue.IsNull
		{
			get { return this == Rectangle.Empty; }
		}

		/// <summary>
		/// Determines whether this instance is null (not set).
		/// </summary>
		internal bool IsNull
		{
			get { return this == Rectangle.Empty; }
		}

		/// <summary>
		/// Calls base class Equals.
		/// </summary>
		public override bool Equals(Object obj)
		{
			if (obj is Rectangle)
			{
				Rectangle o = (Rectangle)obj;
				return 
					_minWidth == o._minWidth &&
					_minHeight == o._minHeight &&
					_cornerRadius == o._cornerRadius &&
					_padding == o._padding &&
					_dashStyle == o._dashStyle &&
					_dashPattern == o._dashPattern &&
					_background == o._background &&
					_foreground == o._foreground;
		  }
		  return false;
		}

		/// <summary>
		/// Gets the ARGB value that this Color instance represents.
		/// </summary>
		public override int GetHashCode()
		{
			int ret = (int) _minWidth.GetHashCode() ^ _minHeight.GetHashCode() ^ _cornerRadius.GetHashCode() ^ 
				_dashStyle.GetHashCode() ^ _background.GetHashCode() ^ _foreground.GetHashCode();

			if (_dashPattern != null)
				ret ^= _dashPattern.GetHashCode();

			return ret;
		}

		/// <summary>
		/// Compares two color objects. True if both argb values are equal, false otherwise.
		/// </summary>
		public static bool operator ==(Rectangle p, Rectangle o)
		{
			return
				p._minWidth == o._minWidth &&
				p._minHeight == o._minHeight &&
				p._cornerRadius == o._cornerRadius &&
				p._padding == o._padding &&
				p._dashStyle == o._dashStyle &&
				p._dashPattern == o._dashPattern &&
				p._background == o._background &&
				p._foreground == o._foreground;
		}

		/// <summary>
		/// Compares two color objects. True if both argb values are not equal, false otherwise.
		/// </summary>
		public static bool operator !=(Rectangle p, Rectangle o)
		{
		  return !(p == o);
		}

		public float MinWidth
		{
			get { return _minWidth; }
			set { _minWidth = value; }
		}

		public float MinHeight
		{
			get { return _minHeight; }
			set { _minHeight = value; }
		}

		public float CornerRadius
		{
			get { return _cornerRadius; }
			set { _cornerRadius = value; }
		}

		public float Padding
		{
			get { return _padding; }
			set { _padding = value; }
		}

		public RectangleBorderStyle DashStyle
		{
			get { return _dashStyle; }
			set { _dashStyle = value; }
		}

		public double[] DashPattern
		{
			get { return _dashPattern; }
			set { _dashPattern = value; }
		}

		public Color Background
		{
			get { return _background; }
			set { _background = value; }
		}

		public Color Foreground
		{
			get { return _foreground; }
			set { _foreground = value; }
		}

		/// <summary>
		/// Writes the Color object in its hexadecimal value.
		/// </summary>
		public override string ToString()
		{
			return "Rectangle";
		}

		float _minWidth;
		float _minHeight;
		float _cornerRadius;
		float _padding;
		RectangleBorderStyle _dashStyle;
		double[] _dashPattern;
		Color _background;
		Color _foreground;
	
		/// <summary>
		/// Represents a null rectangle.
		/// </summary>
		public static readonly Rectangle Empty = new Rectangle();
	  }
}