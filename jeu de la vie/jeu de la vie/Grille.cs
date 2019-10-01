/*
 * Crée par SharpDevelop.
 * Utilisateur: mendu
 * Date: 17/12/2016
 * Heure: 18:29
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace jeu_de_la_vie
{
	/// <summary>
	/// Description of Grille.
	/// </summary>
	public class Grille
	{
	#region prop et atrib
		private int taille;
		private cellule[,] tableauDeCellules;
		private int energie_repro;
		private int age_mort;
		
		public int Age_Mort{
			get{return age_mort;}
			set { age_mort=value;}
			
		}
			public int Energie_Repro{
			get{return energie_repro;}
			set { energie_repro=value;}
		}
		public int Taille{
			get{return taille;}
			set{taille=value;}
		}
		public cellule[,] TableauDeCellules{
			get{return tableauDeCellules;}
			set{tableauDeCellules=value;}
		}
		#endregion
	#region constructeur grille
		public Grille(int taille)
		{
			Age_Mort=10;
			Energie_Repro=8;
			
			
			Taille=taille;
				cellule[,] tableauDeCellules=new cellule[taille,taille];
			for(int i=0;i<taille;i++)
			{
				for(int j=0;j<taille;j++)
				{
					tableauDeCellules[i,j]=new cellule();
					
					if(i==1&&j==3||i==2&&j==1||i==2&&j==3||i==3&&j==2||i==3&&j==3){
						tableauDeCellules[i,j].Vivant=true;
					}
					tableauDeCellules[i,j].PositionX=i;
					tableauDeCellules[i,j].PositionY=j;
				}
			}
			this.TableauDeCellules=tableauDeCellules;
			
		
		}
		public Grille(int taille, int pourcentage)
		{
			cellule[,] tableauDeCellules=new cellule[taille,taille];
			for(int i=0;i<taille;i++)
			{
				for(int j=0;j<taille;j++)
				{
					tableauDeCellules[i,j]=new cellule();
					tableauDeCellules[i,j].PositionX=i;
					tableauDeCellules[i,j].PositionY=j;
				}
			}
			Taille=taille;
			float nb_de_cellule=taille*taille*pourcentage/100;
			
			while(nb_de_cellule>0)
			{
				Random rnd=new Random();
				int i=rnd.Next(0,taille-1);
				int j=rnd.Next(0,taille-1);
				if (!tableauDeCellules[i,j].Vivant)
				{
					tableauDeCellules[i,j].Vivant=true;
					
					nb_de_cellule--;
				}
			}
			this.TableauDeCellules=tableauDeCellules;
			}
		public Grille(int taille, int pourcentage, string libelle,int age, int energie)
		{
			Taille=taille;
			cellule[,] tableauDeCellules=new cellule[taille,taille];
			for(int i=0;i<taille;i++)
			{
				for(int j=0;j<taille;j++)
				{
					tableauDeCellules[i,j]=new cellule(energie,age);
					tableauDeCellules[i,j].PositionX=i;
					tableauDeCellules[i,j].PositionY=j;
				}
			}
			Taille=taille;
			float nb_de_cellule=taille*taille*pourcentage/100;
			
			while(nb_de_cellule>0)
			{
				Random rnd=new Random();
				int i=rnd.Next(0,taille-1);
				int j=rnd.Next(0,taille-1);
				if (!tableauDeCellules[i,j].Vivant)
				{
					tableauDeCellules[i,j].Vivant=true;
					tableauDeCellules[i,j].Energy=energie;
					
					nb_de_cellule--;
				}
			}
			this.TableauDeCellules=tableauDeCellules;
			}
	
		public Grille(string file)
		{
			
		}
		#endregion
	#region voisin
		public cellule VoisinNord(cellule macase)
		{int N=macase.PositionX-1;
			int y=macase.PositionY;
			if (macase.PositionX<=0)
			{
				N=taille-1;
				 
			}
			
			
			
			return TableauDeCellules[N,y];
			
		}	
		
		public cellule VoisinNordEst(cellule macase)
		{
			int nordesty=macase.PositionY+1;
			int nordestx=macase.PositionX-1;
			if (macase.PositionY>=Taille-1)
			{
				 nordesty=Taille-1;
				 
			}
			if (macase.PositionX<=0)
			{
				nordestx=0;
			}
			return TableauDeCellules[nordestx,nordesty];
			
			
			
			
		
	}
		public cellule VoisinNordOuest(cellule macase)
		{
			int NOy=macase.PositionY-1;
			int NOx=macase.PositionX-1;
			if (macase.PositionY<=0)
			{
				 NOy=Taille-1;
				 
			}
			if (macase.PositionX<=0)
			{
				NOx=Taille-1;
			}
			return TableauDeCellules[NOx,NOy];
		}
		public cellule VoisinSud(cellule macase)
		{
			
			int S=macase.PositionX+1;
			
			if (macase.PositionX>=Taille-1)
			{
				S=0;
			}
			return TableauDeCellules[S,macase.PositionY];
		}
 		public cellule VoisinSudEst(cellule macase)
 		{
 			int SEy=macase.PositionY+1;
			int SEx=macase.PositionX+1;
			if (macase.PositionY>=Taille-1)
			{
				 SEy=0;
				 
			}
			if (macase.PositionX>=Taille-1)
			{
				SEx=0;
			}
			return TableauDeCellules[SEx,SEy];
		}
 		public cellule VoisinSudOuest(cellule macase)
 		{
 		int SOy=macase.PositionY-1;
			int SOx=macase.PositionX+1;
			if (macase.PositionY<=0)
			{
				 SOy=Taille-1;
				 
			}
			if (macase.PositionX>=Taille-1)
			{
				SOx=0;
			}
			return TableauDeCellules[SOx,SOy];
		}
		public cellule VoisinOuest(cellule macase)
 		{
 	int O=macase.PositionY-1;
			
			if (macase.PositionY<=0)
			{
				O=Taille-1;
			}
			return TableauDeCellules[macase.PositionX,O];
		}
 		public cellule VoisinEst(cellule macase)
 		{
 			int E=macase.PositionY+1;
			
			if (macase.PositionY>=Taille-1)
			{
				E=0;
			}
			return TableauDeCellules[macase.PositionX,E];
 	
 		}
 		#endregion
 		public void Nbvoisin(cellule mycell)
 		      {
 			mycell.Nbvoisin=0;
 			if(VoisinEst(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinNord(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinSud(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinOuest(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinNordEst(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinNordOuest(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinSudEst(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			if(VoisinSudOuest(mycell).Vivant){
 				mycell.Nbvoisin=mycell.Nbvoisin+1;
 			}
 			//Console.WriteLine(mycell.Nbvoisin);
 		}
 		public void affiche(string message)
 		{
 			
 			for (int i=0;i<Taille;i++)
 			     {
 			     	for(int j=0;j<Taille;j++)
 			     	    {
 			     		if (TableauDeCellules[i,j].Vivant)
 			     		{
 			     			Console.Write("X");
 			     		}
 			     		else{
 			     			Console.Write(" ");
 			     		}
 			     	    }
 			     	Console.WriteLine();
 			     }
 		}
 public cellule Jeuniveau1(cellule macase, int cellulesvoisines)
{
 	
	if(cellulesvoisines>3&&macase.Vivant)
				{
		macase.Vivant=false;
	}
			if(cellulesvoisines<=1&&macase.Vivant)
				{
				macase.Vivant=false;}
			if(cellulesvoisines==3&&!macase.Vivant)
				{
				macase.Vivant=true;}
				
	return macase;
}
 public void clone (Grille magrile)
 {
 	magrile.Taille=this.Taille;
 			for (int i=0;i<Taille;i++)
 			     {
 			     	for(int j=0;j<Taille;j++)
 			     	{
 			     		magrile.TableauDeCellules[i,j].Cloner( this.TableauDeCellules[i,j]);
 			     	}
 			}
 }
 public static void Vrainiveau1(Grille grille,int nombre)
 {
			Grille grillebis=new Grille(grille.Taille);
			grille.affiche("lol");
			Console.ReadKey();
				Console.Clear();
			for (int c=0;c<nombre;c++)
			{
 			for (int i=0;i<grille.Taille;i++)
 			    {
 			     	for(int j=0;j<grille.Taille;j++)
 			     	    {
 			     		
 			     		
 			     		 grille.Nbvoisin(grille.TableauDeCellules[i,j]);
 			     		 
 			     		  grille.Jeuniveau1(grillebis.TableauDeCellules[i,j],grille.TableauDeCellules[i,j].Nbvoisin);
 			     		 
 			     		}
 			     	
 				}
 			grillebis.clone(grille);
 			grille.affiche("lol");
 			
 			Console.ReadKey();
 		
 	Console.Clear();
			}
 
 }
 public cellule Jeuniveau2 (cellule macase, int cellulesvoisines) {
 	macase.Energy+= 4;
 	macase.Age+=1;
 	
 	if(cellulesvoisines>3&&macase.Vivant)
				{
		macase.Vivant=false;
	}
			if(cellulesvoisines<=1&&macase.Vivant)
				{
				macase.Vivant=false;}
			if(cellulesvoisines==3&&!macase.Vivant)
				{
				macase.Vivant=true;}
			if (macase.Energy<=Energie_Repro&& !macase.Vivant&& macase.Age<Age_Mort)
			{
				if (!VoisinEst(macase).Vivant)
				{
				VoisinEst(macase).Vivant=true;
				VoisinEst(macase).Energy=10;// une case qui est reproduit ne pert pas d'energie, a modifier
				VoisinEst(macase).Multi=-1;
				}
				if (!VoisinOuest(macase).Vivant)
				{
				VoisinOuest(macase).Vivant=true;
				VoisinOuest(macase).Energy=10;
				VoisinOuest(macase).Multi=-1;
				}
				if (!VoisinNordEst(macase).Vivant)
				{
				VoisinNordEst(macase).Vivant=true;
				VoisinNordEst(macase).Energy=10;
				VoisinNordEst(macase).Multi=-1;
				}
				if (!VoisinNordOuest(macase).Vivant)
				{
				VoisinNordOuest(macase).Vivant=true;
				VoisinNordOuest(macase).Energy=10;
				VoisinNordOuest(macase).Multi=-1;
				}
				if (!VoisinSudEst(macase).Vivant)
				{
				VoisinSudEst(macase).Vivant=true;
				VoisinSudEst(macase).Energy=10;
				VoisinSudEst(macase).Multi=-1;
				}
				if (!VoisinSudOuest(macase).Vivant)
				{
				VoisinSudOuest(macase).Vivant=true;
				VoisinSudOuest(macase).Energy=10;
				VoisinSudOuest(macase).Multi=-1;	
				}
				if (!VoisinNord(macase).Vivant)
				{
				VoisinNord(macase).Vivant=true;
				VoisinNord(macase).Energy=10;
				VoisinNord(macase).Multi=-1;
				}
				if (!VoisinSud(macase).Vivant)
				{
				VoisinSud(macase).Vivant=true;
				VoisinSud(macase).Energy=10;
				VoisinSud(macase).Multi=-1;
				}
			}
			if (macase.Vivant&&macase.Age==this.Age_Mort)
			{
				macase.Vivant=false;
			}
	return macase;
 }
  public static void Vrainiveau2(Grille grille,int nombre)
 {
			Grille grillebis=new Grille(grille.Taille);
			grille.affiche("lol");
			Console.ReadKey();
			Console.Clear();
			for (int c=0;c<nombre;c++)
			{
 			for (int i=0;i<grille.Taille;i++)
 			    {
 			     	for(int j=0;j<grille.Taille;j++)
 			     	    {
 			     		
 			     		
 			     		 grille.Nbvoisin(grille.TableauDeCellules[i,j]);
 			     		 grille.Jeuniveau2(grillebis.TableauDeCellules[i,j],grille.TableauDeCellules[i,j].Nbvoisin);
 			     		 
 			     		}
 			     	
 				}
 			grillebis.clone(grille);
 			grille.affiche("lol");
 			
 			Console.ReadKey();
 		
 	Console.Clear();
			}
  }
  public static void menu(){
  	Console.WriteLine("choisisez le type de remplissage\n\n1- non aleatoire\n2- aleatoire avec pourcentage\n3- aleatoire avec age et energie a definir");
  	int choix_rempli=0;
  	
  	do{
  		
  		try
  		{
  			choix_rempli=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  	}
  	while(choix_rempli!=1&&choix_rempli!=2&&choix_rempli!=3);
  	Console.Clear();
  	if (choix_rempli==1)
  	{
  		Console.WriteLine("choisissez une taille superieur à 4"); //choix de la taille
  		int taille=0;
  		do {
  		try
  		{
  			taille=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.Clear();
  			Console.WriteLine("recommence!");
  		
  		}
  		}//taille
  		while(taille<4);
  		
  		
  		
  		Console.WriteLine("quel niveau voulez vous?\n1- niveau 1 (pas d'energie et pas d'age)\n2- niveau 2 (age et energie pris en compte)");
  		int choix=0;//niveau
  		do{
  		
  		try
  		{
  			choix=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  	}//niveau
  	while(choix!=1&&choix!=2); 
  	int nombreDeGen=0;
  	Console.WriteLine("choisissez le nombre de gen");
  	 do{
  		
  		try
  		{
  			nombreDeGen=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  	}//nbgen
  	while(nombreDeGen<=0); 
  	Console.Clear();
  		//niveau
  	while(choix!=1&&choix!=2);
  	Grille grille=new Grille(taille);
  	if(choix==1)
  	{
  		Vrainiveau1(grille,nombreDeGen-1);
  	}
  	if(choix==2)
  	{
  		Vrainiveau2(grille,nombreDeGen-1);
  	}
  	}
  	if(choix_rempli==2)
  	{
  		Console.WriteLine("choisissez une taille");
  		int taille=0;
  		do
  		try
  		{
  			taille=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  		while(taille<=0);
  		Console.WriteLine("choisisse un %");
  		
  			int pourcentage=0;
  		do{
  			try
  		{
  			pourcentage=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  		}
  			while(pourcentage>100);
			Grille grille=new Grille(taille,pourcentage);
  	Console.WriteLine("quel niveau voulez vous?\n1- niveau 1 (pas d'energie et pas d'age)\n2- niveau 2 (age et energie pris en compte)");
  		int choix=0;//niveau
  		do{
  		
  		try
  		{
  			choix=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  	}//niveau
  	while(choix!=1&&choix!=2); 
  	int nombreDeGen=0;
  	Console.WriteLine("choisissez le nombre de gen");
  	 do{
  		
  		try
  		{
  			nombreDeGen=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  	}//nbgen
  	while(nombreDeGen<=0); 
  	
  		//niveau
  	while(choix!=1&&choix!=2);
  	if(choix==1)
  	{
  		Vrainiveau1(grille,nombreDeGen-1);
  	}
  	if(choix==2)
  	{
  		Vrainiveau2(grille,nombreDeGen-1);
  	}
  	}
  	  	if(choix_rempli==3)
  	{
  		Console.WriteLine("choisissez une taille");
  		int taille=0;
  		do
  		{
  		try
  		{
  			taille=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  		}
  		while(taille<=0);
  		
  		Console.WriteLine("choisisse un %");
  			int pourcentage=0;
  			do{
  			try
  		{
  			pourcentage=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  		}
  			while(pourcentage>100);
  		
  			Console.WriteLine("choisisse un age");
  			int age=0;
  			do{
  			try
  		{
  			age=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  		}
  			while(age<=0);
  	Console.WriteLine("choisisse une energie");
  			int energie=0;
  			do{
  			try
  		{
  			energie=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  		}
  			while(energie<=0);
  	int nombreDeGen=0;
  	Console.WriteLine("choisissez le nombre de gen");
  	do{
  		
  		try
  		{
  			nombreDeGen=int.Parse(Console.ReadLine());
  			
  		}
  		catch{
  			Console.WriteLine("recommence!");
  		}
  	}//nbgen
  	while(nombreDeGen<=0); 
  	
  		
  	

  	Grille grille=new Grille(taille,pourcentage,"r",age,energie);
  	
  		Vrainiveau2(grille,nombreDeGen-1);
  	
  	}
  }
	}
}