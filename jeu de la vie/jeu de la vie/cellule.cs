/*
 * Crée par SharpDevelop.
 * Utilisateur: mendu
 * Date: 09/12/2016
 * Heure: 18:44
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace jeu_de_la_vie
{
	/// <summary>
	/// Description of cellule.
	/// </summary>
	public class cellule
		
	{
		#region prop et attribu
		private bool vivant;
		private int positionX;
		private int positionY;
		private int nbvoisin;
		private int energy;
		private int age;
		private int multi;
		
		public int Multi{
			get{return multi;}
			set{multi=value;}
		}
		public int Energy{
			get{return energy;}
			set{energy=value;}
		}
		public int Age{
			get{return age;}
			set{age=value;}
		}
		public int Nbvoisin{
			get{return nbvoisin;}
			set{nbvoisin=value;}
				
			}
				
			public int PositionX{
			get{return positionX;}
			set{positionX=value;}
		}
		public int PositionY{
			get{return positionY;}
			set{positionY=value;}
		}
		public bool Vivant{
			get {return vivant;}
			set {vivant=value;}
		}
		#endregion
		public cellule()
		{
			this.Energy=1;
			this.Multi=1;
		}	
		public cellule(int energie, int age         )
		{
			this.Energy=1;
			this.Multi=1;
		}	
		#region methodes
		string toString(){
			string str="la cellule est en vie?"+Vivant+"elle a "+age+"et "+energy+"d'energie"+"est situe en "+PositionX+" "+PositionY;
			return str;
		
		}
	public	void Cloner (cellule mycell){
			
			PositionX=mycell.PositionX;
			PositionY=mycell.PositionY;
			Vivant=mycell.Vivant;
	}
		#endregion
	}
	
}
