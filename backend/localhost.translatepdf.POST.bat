curl http://localhost:8910/translatepdf ^
  -X POST ^
  --data-binary @%1 ^
  --verbose
