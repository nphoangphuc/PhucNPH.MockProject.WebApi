
  
#!/usr/bin/env bash

cd PhucNPH.MockProject.Repository

dotnet ef migrations script -i -o initdb/appSchema.sql -c AppDbContext

perl -e 's/\xef\xbb\xbf//;' -pi~ initdb/appSchema.sql

perl -e 's/\x08//;' -pi~ initdb/appSchema.sql

rm initdb/appSchema.sql~