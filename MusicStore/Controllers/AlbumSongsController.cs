using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AlbumSongsController : Controller
    {
        private readonly MusicStoreContext _context;

        public AlbumSongsController(MusicStoreContext context)
        {
            _context = context;
        }

        // GET: AlbumSongs
        public async Task<IActionResult> Index()
        {
            var musicStoreContext = _context.AlbumSongs.Include(a => a.Album).Include(a => a.Song);
            return View(await musicStoreContext.ToListAsync());
        }

        // GET: AlbumSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSong = await _context.AlbumSongs
                .Include(a => a.Album)
                .Include(a => a.Song)
                .Include(a => a.Song.Artist)
                .FirstOrDefaultAsync(m => m.AlbumSongID == id);
            if (albumSong == null)
            {
                return NotFound();
            }

            return View(albumSong);
        }

        // GET: AlbumSongs/Create
        public IActionResult Create()
        {
            ViewData["AlbumID"] = new SelectList(_context.Albums, "AlbumID", "Title");
            ViewData["SongID"] = new SelectList(_context.Songs, "SongID", "SongTitle");
            return View();
        }

        // POST: AlbumSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumSongID,AlbumID,SongID")] AlbumSong albumSong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albumSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumID"] = new SelectList(_context.Albums, "AlbumID", "Title", albumSong.AlbumID);
            ViewData["SongID"] = new SelectList(_context.Songs, "SongID", "SongTitle", albumSong.SongID);
            return View(albumSong);
        }

        // GET: AlbumSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSong = await _context.AlbumSongs.FindAsync(id);
            if (albumSong == null)
            {
                return NotFound();
            }
            ViewData["AlbumID"] = new SelectList(_context.Albums, "AlbumID", "Title", albumSong.AlbumID);
            ViewData["SongID"] = new SelectList(_context.Songs, "SongID", "SongTitle", albumSong.SongID);
            return View(albumSong);
        }

        // POST: AlbumSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumSongID,AlbumID,SongID")] AlbumSong albumSong)
        {
            if (id != albumSong.AlbumSongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albumSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumSongExists(albumSong.AlbumSongID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumID"] = new SelectList(_context.Albums, "AlbumID", "Title", albumSong.AlbumID);
            ViewData["SongID"] = new SelectList(_context.Songs, "SongID", "SongTitle", albumSong.SongID);
            return View(albumSong);
        }

        // GET: AlbumSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSong = await _context.AlbumSongs
                .Include(a => a.Album)
                .Include(a => a.Song)
                .FirstOrDefaultAsync(m => m.AlbumSongID == id);
            if (albumSong == null)
            {
                return NotFound();
            }

            return View(albumSong);
        }

        // POST: AlbumSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albumSong = await _context.AlbumSongs.FindAsync(id);
            if (albumSong != null)
            {
                _context.AlbumSongs.Remove(albumSong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumSongExists(int id)
        {
            return _context.AlbumSongs.Any(e => e.AlbumSongID == id);
        }
    }
}
