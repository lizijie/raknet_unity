#!/bin/sh
PROJ_PATH=$1
xcodebuild clean -project $PROJ_PATH
xcodebuild -configuration Release -sdk iphoneos ARCHS="arm64" IPHONEOS_DEPLOYMENT_TARGET="10.3" -project $PROJ_PATH