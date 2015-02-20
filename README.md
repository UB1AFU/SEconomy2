# SEconomy2
SEconomy 2.0 - Server-sided Currency, Ranking and Economy plugin for TShock Servers

### SEconomy 2.0 design goals

* **Entirely [Redis](http://redis.io) based**
  * Both SQL and XML journaling systems removed.
  * Redis is an extremely high-performance key-value cache.  With redis, all bank accounts and all transactions move out of TerrariaServer's memory and into redis which is a 64-bit external process
  * Redis is highly concurrent, and can support literally hundreds of thousands of complex operations per second.  On my small Linux VM, Redis benchmarked 130,000 ops/sec whereas mysql barely reached 600 ops/sec on 100k rows of data.  Redis fans like to quote a 60,000x performance increase in subsets of data between Redis and any RDBMS software
  * Redis is easier to install and maintain than any RDBMS.  Simply install and run.
* **Statelessness**
  * Redis fast enough to handle multi-server and multi-state
  * SEconomy now operates stateless, making multi-server possible by connecting to the same redis store
* **Bank accounts removed**
  * Directly referenced by TShock accounts already in RAM, no need to duplicate them
  * Currently because of the disconnect between Terraria accounts and SEconomy accounts, there is a lot of duplication of account information.  Accounts that get removed from TShock stay in SEconomy as orphaned data
* **Bank manager UI removed**
  * Replaced with an easier-to-use web UI (in PHP, Node, anything) connected to the redis database.  Changes made are in real-time, and don't require you to be logged into the server for use
  * Multiple users support, locked out to a permission
* **Multiple currencies**
  * Each currency has individual properties: `earnable`, `spendable`, `tradeable` etc.
  * Can have a normal currency that's spendable and tradable, like as now
  * Can have a static currency that is `earnable` but not `spendable` or `tradeable` called EXP, that only accumulates when a player kills mobs.  
* **Overhauled ranking system**
  * In-built level ranking system, when a user goes over their EXP, automatically changes group (similar to `AutoRank`, thanks *Enerdy*)
  * Overhauled ranking tree system
