call git submodule update --init --recursive Docs
call git submodule foreach git pull origin master
xcopy Docs\content Docs\docs-common\content /s /e /Y
cd Docs\docs-common
call hugo server 
