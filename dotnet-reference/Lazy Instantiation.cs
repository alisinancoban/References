using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            // No allocation of AllTracks object here!
            var mediaPlayer = new MediaPlayer();
            mediaPlayer.Play();

            // Allocation of AllTracks happens when you call GetAllTracks().
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();
        }
    }

    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }
    class AllTracks
    {
        private Song[] allSongs = new Song[10000];
        //private Lazy<Song> allSongs = new Lazy<Song>();
        public AllTracks() { Console.WriteLine("Filling the songs"); }
    }
    class MediaPlayer
    {
        public void Play() { /* Play a song */ }
        public void Pause() { /* Pause the song */ }
        public void Stop() { /* Stop playback */ }
        //private AllTracks allSongs = new AllTracks();
        //public AllTracks GetAllTracks() { return allSongs; }
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() => { Console.WriteLine("Creating AllTracks object!"); return new AllTracks(); });
        public AllTracks GetAllTracks() { return allSongs.Value; }
    }
}





