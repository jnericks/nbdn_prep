("cfarmerga","richlea","rossfuhrman","jaults","karthikg","amolina82","mmarksbury","jzimmerman7","bsnbdn","toddlangdon") | foreach-object{
  git remote add $_ "git://github.com/$_/nbdn_prep.git"
}
