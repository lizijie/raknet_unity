#!/bin/sh
PROJ_PATH=$1
xcodebuild clean -project $PROJ_PATH
xcodebuild -configuration Release -sdk iphoneos ARCHS="arm64 armv7" IPHONEOS_DEPLOYMENT_TARGET="10.3" ENABLE_BITCODE="NO" -project $PROJ_PATH
