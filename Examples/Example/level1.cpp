#include "Level1.h"

#include "Floor.h"
#include "Wall.h"
#include "Dwarf.h"
#include "Elf.h"
#include "Wizard.h"

void Level1::setupLevel() {
makeFloorAtTile(0 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(0 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 320 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 288 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 256 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 224 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 192 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 160 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(320 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 0 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(32 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(96 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(64 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 32 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(288 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 128 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(128 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(256 / 32, 64 / 32, "assets/sprites/floor.png");
makeFloorAtTile(224 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(192 / 32, 96 / 32, "assets/sprites/floor.png");
makeFloorAtTile(160 / 32, 96 / 32, "assets/sprites/floor.png");

makeWallAtTile(0 / 32, 64 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 32 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(32 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(64 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(96 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 96 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(32 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(64 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(96 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(128 / 32, 64 / 32, "assets/sprites/wall.png");
makeWallAtTile(128 / 32, 32 / 32, "assets/sprites/wall.png");
makeWallAtTile(128 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(128 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 64 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(192 / 32, 64 / 32, "assets/sprites/wall.png");
makeWallAtTile(288 / 32, 64 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 64 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 160 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 192 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(32 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(64 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(96 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(128 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(192 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(224 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(256 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(288 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 320 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 288 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 256 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 224 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 192 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 160 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 96 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 224 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 288 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 256 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 224 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 192 / 32, "assets/sprites/wall.png");
makeWallAtTile(0 / 32, 160 / 32, "assets/sprites/wall.png");
makeWallAtTile(160 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(192 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(224 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(256 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(288 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 0 / 32, "assets/sprites/wall.png");
makeWallAtTile(320 / 32, 32 / 32, "assets/sprites/wall.png");
makeWallAtTile(192 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(224 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(288 / 32, 128 / 32, "assets/sprites/wall.png");
makeWallAtTile(256 / 32, 64 / 32, "assets/sprites/wall.png");

{
Dwarf *dwarf = new Dwarf();
dwarf->setPosition(56, 176);
addEnemy(dwarf);
}
{
Dwarf *dwarf = new Dwarf();
dwarf->setPosition(77, 272);
addEnemy(dwarf);
}
{
Dwarf *dwarf = new Dwarf();
dwarf->setPosition(258, 242);
addEnemy(dwarf);
}

{
Elf *elf = new Elf();
elf->setPosition(167, 33);
addEnemy(elf);
}
{
Elf *elf = new Elf();
elf->setPosition(288, 34);
addEnemy(elf);
}

{
Player *player = new Wizard();
player->setPosition(48, 46);
addPlayer(player);
}
}