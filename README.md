# Pixygon — ID System

The universal **content-identity** system. Every piece of Pixygon content — stats,
items, animas, avatar parts, skills, quests, even wiki pages — is keyed by a stable
id so it can be referenced the same way across every game and the lore wiki.

## Overview

A content entry's identity is `categoryId` + `id`, combined into a stable
**full id** (`GetFullID` = `categoryId` concatenated with the 4-digit `id`, e.g.
`030001`). The id is the identity; display names and data can change, the id never
does. This is the key the whole platform (and the pixygon.io wiki) hangs off.

## Key types

| Type | What it is |
|---|---|
| **`IdObject`** | Base `ScriptableObject` for any identified content. `categoryId` + `id` → `GetFullID` (int) / `GetFullIDString` (`"CCdddd"`). Subclass it (e.g. `StatDefinition`, `AnimaDefinition`). |
| **`IdCategoryList`** | A named group of `IdObject`s (`_groupName`, `_groupId`, `_list`). |
| **`IdGroup`** | A `ScriptableObject` catalog of categories. Look up by `GetObject(categoryId, id)`, by `(name, id)`, or by full-id string `GetObject("CCdddd")`. |
| **`IdTag`** | A lightweight serializable reference: `categoryId` + `id` + `IdType`. Use it to point at content without holding the asset. |
| **`IdType`** | Enum of content kinds: `Actor, Quest, Item, Avatar, Effect, Profession, Conversation, Application`. *(Note: the platform's actors/avatar work aligns with these.)* |
| **`IDSystem`** | MonoBehaviour stub (reserved). |

## Dependencies

None — this is the foundation everything else builds on.

## Usage

```csharp
public class AnimaDefinition : Pixygon.ID.IdObject { /* … */ }
// author the asset, set categoryId + id
var anima = idGroup.GetObject("050012");      // category 05, id 0012
int key = animaDefinition.GetFullID;          // stable cross-game / wiki key
```

## Status

`0.5.0`. Stable and widely depended-on. `IdObject` is a Unity `ScriptableObject`;
for the future Pixygon Engine a pure-C# id mirror can be extracted, but the
`categoryId·id` scheme itself is engine-agnostic.
