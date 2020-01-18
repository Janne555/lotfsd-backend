﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lotfsd.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lotfsd.Data
{
  public class DataStore
  {
    private readonly LotfsdContext _lotfsdContext;

    public DataStore(LotfsdContext lotfsdContext)
    {
      _lotfsdContext = lotfsdContext;
    }

    public async Task<CharacterSheet> AddCharacterSheetAsync(CharacterSheet characterSheet)
    {
      _lotfsdContext.CharacterSheets.Add(characterSheet);
      await _lotfsdContext.SaveChangesAsync();
      return characterSheet;
    }

    public CharacterSheet AddCharacterSheet(CharacterSheet characterSheet)
    {
      _lotfsdContext.CharacterSheets.Add(characterSheet);
      _lotfsdContext.SaveChanges();
      return characterSheet;
    }

    public List<CharacterSheet> GetCharacterSheets(Guid userId)
    {
      return _lotfsdContext
        .CharacterSheets
        .Where(ch => ch.UserId.Equals(userId))
        .Include(ch => ch.Inventory)
        .Include(ch => ch.Properties)
        .Include(ch => ch.Retainers)
        .Include(ch => ch.Effects)
        .ToList();
    }

    public CharacterSheet GetCharacterSheet(Guid userId, string characterSheetId)
    {
      return _lotfsdContext.CharacterSheets
        .Where(x => x.UserId.Equals(userId))
        .Where(x => x.Guid == characterSheetId)
        .Include(ch => ch.Inventory)
        .Include(ch => ch.Properties)
        .Include(ch => ch.Retainers)
        .Include(ch => ch.Effects)
        .FirstOrDefault();
    }

    public List<CharacterSheet> DeleteCharacterSheet(Guid userId, string charactersheetId)
    {
      var characterSheet = _lotfsdContext
        .CharacterSheets
        .Where(ch => ch.Guid.Equals(charactersheetId) && ch.UserId.Equals(userId))
        .FirstOrDefault();
      if (characterSheet == null)
      {
        throw new Exception("Character sheet not found");
      }

      _lotfsdContext.CharacterSheets.Remove(characterSheet);
      _lotfsdContext.SaveChanges();
      return GetCharacterSheets(userId);
    }

    public CharacterSheet UpdateCharacterSheet(dynamic updatedCharacterSheet, string characterSheetId)
    {
      var characterSheet = _lotfsdContext
        .CharacterSheets
        .Where(ch => ch.Guid.Equals(characterSheetId))
        .FirstOrDefault();

      if (characterSheet == null)
      {
        throw new Exception("Character sheet not found");
      }

      var characterSheetType = Type.GetType("Lotfsd.Data.Models.CharacterSheet");

      foreach (var item in updatedCharacterSheet)
      {
        string key = item.Key;
        characterSheetType
          .GetProperty(char.ToUpper(key[0]) + key.Substring(1))
          .SetValue(characterSheet, item.Value);
      }

      _lotfsdContext.SaveChanges();
      return characterSheet;
    }
  }
}
