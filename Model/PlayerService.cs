﻿using Service.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Model.StorageService;

namespace Service
{
    public class PlayerService
    {
        public List<T002_Player> RawPlayers { get; }
        public List<DisplayPlayer> DisplayPlayers { get; }

        public PlayerService()
        {
            RawPlayers = getRawPlayers();
            DisplayPlayers = getDisplayPlayers();

        }

            private List<T002_Player> getRawPlayers()
        {
            List<T002_Player> playerlist = new List<Domain.T002_Player>();

            using (var dbc = new TeamDBEntities())
            {
                return dbc.T002_Player.ToList();
            }
        }

        private List<DisplayPlayer> getDisplayPlayers()
        {
            var ts = new TeamService();
            var ss = new StorageService();
            var displayPlayers = new List<DisplayPlayer>();
            foreach (var rawPlayer in RawPlayers)
            {
                var displayPlayer = new DisplayPlayer();
                displayPlayer.importRawPlayer(rawPlayer);
                displayPlayer.TeamName = ts.getTeamNameById(rawPlayer.TeamId);
                displayPlayer.profilePictureURL = ss.getURL(rawPlayer.Id.ToString());
                displayPlayers.Add(displayPlayer);
            }
            return displayPlayers;
        }

        public T002_Player getPlayerById(int id)
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T002_Player.Where(player => player.Id == id).First();
            }
        }

        public List<T002_Player> getPlayersByTeam(T001_Teams team)
        {
            var c = team.T002_Player.ToList();
            return team.T002_Player.ToList();
        }
    }
}
