using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace TPLOCAL1
{
    public class ListeAvis
    {
        /// <summary>
        /// Fonction permettant de récupérer la liste des avis contenus dans un fichier XML.
        /// </summary>
        /// <param name="fichier">Chemin du fichier XML</param>
        /// <returns>Liste d'objets Avis</returns>
        public List<Avis> GetAvis(string fichier)
        {
            // Instancier la liste comme vide
            List<Avis> listeAvis = new List<Avis>();

            // Création d'un objet XmlDocument pour récupérer les données du fichier
            XmlDocument xmlDoc = new XmlDocument();

            // Lecture du fichier via un StreamReader
            StreamReader streamDoc = new StreamReader(fichier);
            string dataXml = streamDoc.ReadToEnd();

            // Chargement des données dans le XmlDocument
            xmlDoc.LoadXml(dataXml);

            // Récupération des nœuds pour les transformer en objets Avis
            // et les ajouter à la liste 'listeAvis'.
            // On boucle sur chaque nœud de type XmlNode ayant pour chemin "root/row"
            // (cf. structure du fichier XML).
            // La méthode SelectNodes récupère tous les nœuds correspondant au chemin spécifié.
            foreach (XmlNode noeud in xmlDoc.SelectNodes("root/row"))
            {
                // Récupération des données dans les nœuds enfants
                string nom = noeud["Nom"].InnerText;
                string prenom = noeud["Prenom"].InnerText;
                string avisDonne = noeud["Avis"].InnerText;

                // Création de l'objet Avis à ajouter à la liste
                Avis avis = new Avis
                {
                    Nom = nom,
                    Prenom = prenom,
                    AvisDonne = avisDonne
                };

                // Ajout de l'objet à la liste
                listeAvis.Add(avis);
            }

            // La liste constituée est renvoyée à la méthode appelante
            return listeAvis;
        }
    }

    /// <summary>
    /// Classe regroupant les données relatives aux avis.
    /// </summary>
    public class Avis
    {
        /// <summary>
        /// Nom de famille
        /// </summary>
        public required string Nom { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public required string Prenom { get; set; }

        /// <summary>
        /// Avis donné (Valeurs possibles : O ou N)
        /// </summary>
        public required string AvisDonne { get; set; }
    }
}