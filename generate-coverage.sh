#!/bin/bash

outdir="$(pwd)/Tests/TestResults"
coveragefile="$outdir/coverage.cobertura.xml"

# Run tests with coverage
dotnet test Tests/Tests.csproj \
  -p:CollectCoverage=true \
  -p:CoverletOutputFormat=cobertura \
  -p:CoverletOutput="$(pwd)/Tests/TestResults/coverage" \
  -p:Exclude=\"[xunit*]*,[*.Tests]*\" \
  --logger "console;verbosity=detailed" || true

# Generate HTML report
reportgenerator "-reports:$coveragefile" "-targetdir:$outdir/Reports" "-reporttypes:Html"

# Open report in default browser (Windows)
if [[ -f "Tests/TestResults/Reports/index.html" ]]; then
    start "Tests/TestResults/Reports/index.html"
else
    echo "Error: Report generation failed - file not found"
fi