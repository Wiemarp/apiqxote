# API Qxote Documentation:
## Getting started
Please clone the repository and connect it to your local host before use!

### How to clone the repository
[Work in progress...]

### How to connect to localhost
[Work in progress...]

## Database
**Decimals can go to two digits**

There are five tables inside of the database.
**The "zone" table consists of this data:**
- zone [primary key] (a unique letter from A - Z. Each letter can ONLY BE USED ONCE!)
- area (a number that defines how big the area is in m2)
- classification [enum] (a multiple-choice which contains the options 'homogenuis', 'no_homogenuis', 'transition')
- plots (a number that defines the amount of plots the zone contains)

**The "plant" table consists of this data:**
- plot_nr [primary key] (a shortcode that defines a plot: "ZAP1", "ZBP5", etc.)
- zone [foreign key] (this variable can be selected. The options you can choose from are registered in the zone table)
- coordinate (an IP address that describes where the plant is located)
- species (the Latin name for the plant)
- cover (a percentage from 1 - 100 that defines how much of the area the plant covers)
- temperature (a number that describes the temperature in Celius of the weather outside when the plant was recorded)
- humidity (a percentage from 1 - 100 that describes the humidity of the air)
- date (a date in the format of YYYY-MM-DD or year-month-day of when the plant was recorded)

The "plant" table is linked to the "zone" table.
There can be *multiple* plants in *one zone*!


**The "tree" table consists of this data:**
- tree_id [primary key] (a unique number for each tree. Each number can ONLY BE USED ONCE!)
- tree_nr (defines the tree number from an area area)
- coordinate (an IP address that describes where the plant is located)
- height (defines the height of the tree in meters)
- circumference (a decimal that describes the circumference of a tree)
- volume (a decimal that describes the volume of the tree)
- bio_concentration_id [foreign key] (a number that is connected to the type of tree from the "bio_concentration" table)
- tree_name [foreign key] (a number that is connected to the name of the tree from the "tree_name" table)
- zone [foreign key] (a letter that is connected to the zone letter from the "zone" table)

The "tree" table is linked to the "zone" table.
There can be *multiple* trees but each tree has *one* tree type!


**The "bio_concentration" table consists of this data:**
- id [primary key] (a unique ID given with each type, this value is automatically added by the database)
- species (defines the type of tree wood)
- bcf (a decimal)
- cf (a decimal)
- r (a decimal)
- ctree (a decimal)

The "bio_concentration" table is linked to the "tree" table.

**The "tree_name" table consists of this data:**
- tree_name [primary key] (the Latin name for the tree)
- coordinate_count (the number of trees that are on this coördinate)

The "tree_name" table is linked to the "tree" table.


**The "animal" table consists of this data:**
- animal_id [primary key] (a unique ID given with each type, this value is automatically added by the database)
- animal_type [enum] (type of animal spotted, the options are: 'nocturnal_butterfly, diurnal_butterfly, bird, reptile)
- date (a date in the format of YYYY-MM-DD or year-month-day of when the animal was recorded)
- start_time (the time HH:MM or hours:minutes when the recording of the animal has started)
- end_time (the time HH:MM or hours:minutes when the recording of the animal has ended)
- temperature (the temperature of the weather in Celsius was when the animal was recorded)
- cloud_cover (the amount of cloud cover there was during the recording)
- wind_speed (the wind speed during the recording of the animal)
- species_name (the Latin name of the species)
- coordinate (the coordinate where the animal was recorded)
- abundance (the amount of the animal spotted)
- overboard (not exactly sure what it is other than an int **ASK LATER WHAT THIS MEANS**)
- zone [foreign key] (a letter that is connected to the zone letter from the "zone" table where the animal was recorded)

The "animal" table is linked to the "zone" table.
There can be *multiple* animals spotted in *one zone*!

## API Documentation
[Work in progress...]
