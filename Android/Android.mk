LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

# override strip command to strip all symbols from output library; no need to ship with those..
# cmd-strip = $(TOOLCHAIN_PREFIX)strip $1 

SRC_LIST := $(wildcard $(LOCAL_PATH)/../Source/*.cpp)
SRC_LIST += $(wildcard $(LOCAL_PATH)/../Source/RakNet_wrap.cxx)

LOCAL_ARM_MODE  := arm
LOCAL_PATH      := $(NDK_PROJECT_PATH)
LOCAL_MODULE    := libRakNet
LOCAL_CPP_FEATURES := exceptions
LOCAL_SRC_FILES := $(SRC_LIST:$(LOCAL_PATH)/%=%)
LOCAL_LDLIBS    := -llog

include $(BUILD_SHARED_LIBRARY)
