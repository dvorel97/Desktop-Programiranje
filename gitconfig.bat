@echo off
setlocal

set "username=David Vorel"
set "email=dvorel@vub.hr"

git config --global user.name "%username%"
git config --global user.email "%email%"

echo Git Global Config Updated!